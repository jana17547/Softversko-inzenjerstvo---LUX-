using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using projekat.JWTHelper;

namespace Projekat.Models
{
  [Table("Korisnik")]
  public class Korisnik
  {
    [Key]
    [Column("KorisnikId")]
    public int KorisnikId { get; set; }

    [Column("Ime")]
    [MaxLength(50)]
    public string Ime { get; set; }

    [Column("Prezime")]
    [MaxLength(50)]
    public string Prezime { get; set; }

    [Column("Email")]
    public string Email { get; set; }

    [Column("KorisnickoIme")]
    public string KorisnickoIme { get; set; }

    [Column("Sifra")]
    [MinLength(8)]
    public string Sifra { get; set; }

    [Column("BrojOnlineKupovina")]
    public int BrojOnlineKupovina { get; set; }

    [Column("Telefon")]
    public string Telefon { get; set; }

    [Column("Adresa")]
    public string Adresa { get; set; }

    [Column("Slika")]
    public byte[] Slika { get; set; }

    [Column("Obrisan")]
    public bool Obrisan { get; set; }

    [Column("TipKorisnika")]
    public Role TipKorisnika { get; set; }

    public List<Komentar> Komentari { get; set; }

  }
}