using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prijava;
using Registracija;

namespace Testovi
{
    [TestClass]
    public class Testovi
    {
        /// <summary>
        /// Author: Nikola Muše
        /// </summary>
        [TestMethod]
        public void Provjera_prijave_korisnika_test()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsTrue(autentifikator.prijava("bkvesic7", "bozo123"));
        }
        /// <summary>
        /// Author: Nikola Muše
        /// </summary>
        [TestMethod]
        public void Provjera_prijave_korisnika_test_nije_ispravno()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsFalse(autentifikator.prijava("bkvesic7", "bozo1234"));
        }
        /// <summary>
        /// Author: Nikola Muše
        /// </summary>
        [TestMethod]
        public void Provjera_uloge_korisnika()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsFalse(autentifikator.tipKorisnika("bkvesic7") == 3);
        }
        /// <summary>
        /// Author: Nikola Muše
        /// </summary>
        [TestMethod]
        public void Provjera_uloge_korisnika_valja()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsTrue(autentifikator.tipKorisnika("bkvesic7")==1);
        }
        /// <summary>
        /// Author: Nikola Muše
        /// </summary>
        [TestMethod]
        public void Provjera_postojanja_korisnika()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsNull(autentifikator.findKorisnik("bkvesic7"));
        }
        /// <summary>
        /// Author: Nikola Muše
        /// </summary>
        [TestMethod]
        public void Provjera_postojanja_korisnika_ne_postoji()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.IsNotNull(autentifikator.findKorisnik("bozo.kvesic1@gmail.com"));
        }
        /// <summary>
        /// Author: Anabela Pranjić
        /// </summary>
        [TestMethod]
        public void Provjera_korime_izmedu_5_i_15()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.provjeriKorisnika("111"));
        }
        /// <summary>
        /// Author: Anabela Pranjić
        /// </summary>
        [TestMethod]
        public void Provjera_korime_postoji_u_bazi()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.provjeriKorisnika1("bkvesic7"));
        }
        /// <summary>
        /// Author: Anabela Pranjić
        /// </summary>
        [TestMethod]
        public void Provjera_korime_sadrži_slovo_i_broj()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.provjeriKorisnika2("bkvesic"));
        }
        /// <summary>
        /// Author: Anabela Pranjić
        /// </summary>
        [TestMethod]
        public void Provjera_email_postoji_u_bazi()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.postojiEmail("bozo.kvesic@gmail.com"));
        }
        /// <summary>
        /// Author: Anabela Pranjić
        /// </summary>
        [TestMethod]
        public void Provjera_email_ne_postoji_u_bazi()
        {
            Autentifikator autentifikator = new Autentifikator();
            Assert.ThrowsException<PrijavaException>(() => autentifikator.NePostojiEmail("bozo.kvesic1@gmail.com"));
        }
        /// <summary>
        /// Author: Anabela Pranjić
        /// </summary>
        [TestMethod]
        public void Provjera_mobilnog_broja()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsFalse(autentifikator.IsMobilePhoneCorrect("094m4m44343443"));
        }
        /// <summary>
        /// Author: Božo Kvesić
        /// </summary>
        [TestMethod]
        public void Provjera_mobilnog_broja2()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsMobilePhoneCorrect("098644646464"));
        }
        /// <summary>
        /// Author: Božo Kvesić
        /// </summary>
        [TestMethod]
        public void Provjera_imena()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsFalse(autentifikator.IsNameSurnameValid("n3dsaamd331"));
        }
        /// <summary>
        /// Author: Božo Kvesić
        /// </summary>
        [TestMethod]
        public void Provjera_imena_ispravno()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsNameSurnameValid("Ivan"));
        }
        /// <summary>
        /// Author: Božo Kvesić
        /// </summary>
        [TestMethod]
        public void Provjera_dvije_lozinke()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsPasswordsSame("ivan1233","ivan1233"));
        }
        /// <summary>
        /// Author: Božo Kvesić
        /// </summary>
        [TestMethod]
        public void Provjera_dvije_lozinke_neispravno()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsFalse(autentifikator.IsPasswordsSame("ivan1233", "ivan564"));
        }
        /// <summary>
        /// Author: Božo Kvesić
        /// </summary>
        [TestMethod]
        public void Provjera_emaila()
        {
            AutentifikacijaRegistracije autentifikator = new AutentifikacijaRegistracije();
            Assert.IsTrue(autentifikator.IsValidEmail("bozo.kvesic@gmail.com"));
        }
    }
}
