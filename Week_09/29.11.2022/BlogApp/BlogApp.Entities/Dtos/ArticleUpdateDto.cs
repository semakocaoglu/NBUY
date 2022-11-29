using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Dtos
{
    public class ArticleUpdateDto
    {

        [Required]
        public int Id { get; set; } 

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "{0} alanının uzunluğu {1} karakteri geçmemelidir")]
        [MinLength(5, ErrorMessage = "{0} alanının uzunluğu {1} karakterden az olmamalıdır")]
        public string Title { get; set; }




        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanının uzunluğu {1} karakterden az olmamalıdır")]
        public string Content { get; set; }






        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(250, ErrorMessage = "{0} alanının uzunluğu {1} karakteri geçmemelidir")]
        [MinLength(5, ErrorMessage = "{0} alanının uzunluğu {1} karakterden az olmamalıdır")]
        public string Thumbnail { get; set; }




        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }




        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "{0} alanının uzunluğu {1} karakteri geçmemelidir")]
        public string SeoAuthor { get; set; }




        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(150, ErrorMessage = "{0} alanının uzunluğu {1} karakteri geçmemelidir")]
        public string SeoDescription { get; set; }




        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(70, ErrorMessage = "{0} alanının uzunluğu {1} karakteri geçmemelidir")]
        public string SeoTags { get; set; }


        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public int CategoryId { get; set; }


        public Category Category { get; set; }


        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public bool IsActive { get; set; }




        [DisplayName("Silinsin mi?")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public bool IsDeleted { get; set; }

    }
}
