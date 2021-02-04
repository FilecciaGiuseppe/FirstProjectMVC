using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Paragraphe")]
    public class Paragraphe
    {
        #region Propriétés
        [Key]
        public int Id { get; set; }

        [Range(1,999999)]
        public int Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Titre requis")]
        public string Titre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description requise")]
        public string Description { get; set; }

        //Indique si c'est le paragraphe de démarrage
        public bool EstInitial { get; set; }
        public Question MaQuestion { get; set; }

        //Liste des réponses possibles
        public IEnumerable<Reponse> Reponses { get; set; }

        #endregion
    }
}
