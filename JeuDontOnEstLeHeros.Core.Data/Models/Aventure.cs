using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Aventure")]
    public class Aventure
    {
        #region Propriétés
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le titre est requis")]
        public string Titre { get; set; }

        #endregion
    }
}
