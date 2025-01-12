using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using projekat.JWTHelper;
using Projekat.Models;


namespace Proba.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TransakcijaController : ControllerBase
  {
    public ShopContext Context { get; set; }

    public TransakcijaController(ShopContext context)
    {
      Context = context;
    }

    [Authorize(Role.User)]
    [Route("GetTransakcija/{korId}")]
    [HttpGet]
    public async Task<ActionResult> GetTransakcija(int korId)
    {
      try
      {
        var k = await Context.Transakcije.Where(p => p.Korisnik.KorisnikId == korId).Include(q => q.Artikal).Select(a => new
        {
          naziv = a.Artikal.Naziv,
          opis = a.Artikal.Opis,
          kolicina = a.Kolicina,
          cena = a.Artikal.Cena,
          cenaPopust = a.CenaSaPopustom

        }).ToArrayAsync();
        return Ok(k);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [Authorize(Role.Admin)]
    [Route("VratiTransakcije")]
    [HttpGet]
    public async Task<ActionResult> VratiTransakcije()
    {
      try
      {
        var k = await Context.Transakcije.Where(p => p.transakcijaId != 0).Include(a => a.Artikal).Include(k => k.Korisnik).Select(p => new
        {
          transakcijaId = p.transakcijaId,
          kolicina = p.Kolicina,
          adresa = p.Adresa,
          naziv = p.Artikal.Naziv,
          korisnickoIme = p.Korisnik.KorisnickoIme

        }).ToArrayAsync();
        return Ok(k);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [Authorize(Role.Admin)]
    [Route("VratiZaradu")]
    [HttpGet]
    public async Task<ActionResult> VratiZaradu()
    {
      try
      {
        var suma = Context.Transakcije.Sum(x => x.CenaSaPopustom * x.Kolicina);

        return Ok(suma);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [Authorize(Role.User)]
    [Route("PostTransakcija/{idKor}/{artikalId}/{kol}/{adresa}/{cenaPopust}")]
    [HttpPost]
    public async Task<ActionResult> DodajTransakciju(int idKor, int artikalId, int kol, string adresa, double cenaPopust)
    {
      if (artikalId < 0)
      {
        return BadRequest("Nije unet artikal!");
      }
      if (idKor < 0)
      {
        return BadRequest("Nije unet korisnik!");
      }
      try
      {
        var kor = await Context.Korisnici.Where(p => p.KorisnikId == idKor).FirstOrDefaultAsync();
        if (kor == null)
        {
          return BadRequest("Korisnik ne postoji!");
        }
        int brKupovina = kor.BrojOnlineKupovina;
        Artikal a;
        a = await Context.Artikli.Where(p => p.ArtikalId == artikalId).FirstOrDefaultAsync();
        if (a == null)
        {
          return BadRequest("Ne postoji artikal!");
        }
        int brProdatih = a.BrojProdaja;
        Transakcija tr = new Transakcija
        {
          Korisnik = kor,
          Artikal = a,
        };
        tr.Kolicina = kol;
        tr.Adresa = adresa;
        tr.CenaSaPopustom = cenaPopust;

        if (tr.Kolicina > a.NaStanju)
        {
          return BadRequest($"Na stanju imamo samo jos: {a.NaStanju} artikla");
        }
        a.BrojProdaja += tr.Kolicina;
        a.NaStanju -= tr.Kolicina;
        kor.BrojOnlineKupovina++;
        Context.Transakcije.Add(tr);
        await Context.SaveChangesAsync();
        return Ok(tr.Korisnik);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [Authorize]
    [Route("DeleteTransakcija/{id}")]
    [HttpDelete]
    public async Task<ActionResult> Izbrisi(int id)
    {
      if (id <= 0)
      {
        return BadRequest("Pogrešan ID!");
      }

      try
      {
        var tr = await Context.Transakcije.FindAsync(id);
        Context.Transakcije.Remove(tr);
        await Context.SaveChangesAsync();
        return Ok($"Uspešno izbrisana transakcija sa id: {tr.transakcijaId}");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}