using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Question")]
    public class Question
    {
        #region Propriétés
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public int ParagrapheId { get; set; }

        //liste des réponses possibles
        public List<Reponse> MesReponses { get; set; }

        #endregion
    }
}
