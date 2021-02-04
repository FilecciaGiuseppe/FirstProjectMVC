using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JeuDontOnEstLeHeros.Core.Data.Models
{
    [Table("Proposition")]
    public class Reponse
    {
        #region Propriétés
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public int QuestionId { get; set; }

        //ID du paragraphe suivant
        public int ParagrapheId { get; set; }

        

        #endregion
    }
}
