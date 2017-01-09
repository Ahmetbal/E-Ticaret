using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models
{
    [Table("Kullanici")]
    public class Kullanici
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [StringLength(20, ErrorMessage = "{0} en fazla {1} karakter olabilir."), DisplayName("Kullanıcı Adı")]
        public string KULLANICIADI { get; set; }

        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [StringLength(250, ErrorMessage = "{0} en fazla {1} karakter olabilir."), DisplayName("Şifre")]
        public string SIFRE { get; set; }

        [StringLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir."), Required(ErrorMessage = "{0} boş geçilemez."), DisplayName("Ad")]
        public string AD{ get; set; }

        [StringLength(25, ErrorMessage = "{0} en fazla {1} karakter olabilir."), Required(ErrorMessage = "{0} boş geçilemez."), DisplayName("Soyad")]
        public string SOYAD { get; set; }

        [StringLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir."), Required(ErrorMessage = "{0} boş geçilemez."), DisplayName("E-posta")]
        public string EPOSTA { get; set; }

        [StringLength(10, ErrorMessage = "{0} en fazla {1} karakter olabilir."), DisplayName("Cep telefonu")] 
        public string CEPTELEFONU { get; set; }

        [DisplayName("Son Giriş")]
        [DataType(DataType.DateTime)]
        public DateTime? SONGIRIS { get; set; }


        [DisplayName("Son Çıkış")]
        [DataType(DataType.DateTime)]
        public DateTime? SONCIKIS { get; set; }

    }
}