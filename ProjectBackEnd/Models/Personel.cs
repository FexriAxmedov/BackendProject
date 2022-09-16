using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
   public class Personel
    {     
        public string saheAdi { get; set; }
        [Required, MaxLength(100)]
        public int isciNomresi { get; set; }
        [Required,MaxLength(25)]
        public string Ad { get; set; }
        [Required, MaxLength(25)]
        public string Soyadi { get; set; }
        [Required, MaxLength(8)]
        public DateTime iseGirisVaxti { get; set; }
        [Required, MaxLength]
        public string Unvan { get; set; }
       [Required]
        public decimal emekHaqqiEmsali { get; set; }
        public int birAydaCalisdigiMuddet { get; set; }
        
    }
}
