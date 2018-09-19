using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wiky.Models
{
   
        [MetadataType(typeof(PostMetaData))]
        public partial class Art
        {
        }

        public class PostMetaData
        {
            [Required]
            [Display(Name = "Auteur")]
            //ResourceType = typeof(RessourceView))] => pour les langues: internationalisation
            public virtual string Auteur { get; set; }

            [StringLength(20)]
            [Required]
            [Display(Name = "Theme")]
           // ResourceType = typeof(RessourceView))]
            [Remote("ChekIfThemeAlreadyExist", "Home")]//, ErrorMessageRessourceType = typeof(Ressourceview)]
            public virtual string Theme { get; set; }

        }
    
}