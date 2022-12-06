$(document).ready(function () {
    //Datatable burada başlıyor
    $('#categoriesTable').DataTable({

        dom: "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: 'btnAdd'
                },
                action: function (e, dt, node, config) {

                },
                className: 'btn btn-success'
            },
            {
                text: 'Yenile',
                action: function (e, dt, node, config) {
                    //Burada yenile butonuna basıldığında Ajax ile içeriğimizi yenileyeceğiz.
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Category/GetAllCategories/', // Category controllerındaki GetAllCategories çalştır
                        contentType: 'application/json',
                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.spinner-border').show(); //yukarıdaki spinnerı göstermeyi sağlar.
                        },
                        success: function (data) {  //data'nın içinde yukardan gelen bilgiler var
                            const categoryListDto = jQuery.parseJSON(data);


                            if (categoryListDto.ResultStatus === 0) {
                                let tableBody = '';
                                $.each(categoryListDto.Categories.$values, function (index, category) {      //each:jQueryde döngüdür

                                    tableBody += `
                                    <tr name="${category.Id}">
                                        <td>${category.Id}</td>
                                        <td>${category.Name}</td>
                                        <td>${category.Description}</td>
                                        <td>${convertFirstLetterToUpperCase(category.IsActive)}</td>
                                        <td>${convertToShortDate(category.CreatedDate)}</td>
                                        <td>${category.CreatedByName}</td>
                                     <td>
                                    <button class="btn btn-warning btn-sm btn-update" data-id="${category.Id}"><span class="fas fa-edit text-white"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${category.Id}"><span class="fas fa-minus-circle"></span></button
                                      </td>
                                     


                                                                    <tr>
                                                                  `;
                                });
                                $('#categoriesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1000);

                            } else {
                                toastr.error(`${categoryListDto.Message}`, 'İşlem başarsız');
                            }

                        },
                        error: function (err) {

                        }


                    });
                },
                className: 'btn btn-warning'
            }
        ],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.13.1/i18n/tr.json'
        }
    });



    $(function () {
        const url = '/Admin/Category/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        //Ajax'la partial viewimizi ekrana getirme
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) { //yukarıdaki url'deki Add functionını çalıştır.
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');

            });
        });
        //Ajax'la (GET) partial viewimizi ekrana getirme BİTTİ

        //Ajax'la POST işlemleri
        placeHolderDiv.on('click', '#btnSave', function (event) {

            event.preventDefault();
            const form = $('#form-category-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const categoryAddAjaxModel = jQuery.parseJSON(data);
                const newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    const newTableRow = `
                              <tr name="${categoryAddAjaxModel.CategoryDto.Category.Id}">
                                  <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                  <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                  <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                  <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsActive)}</td>
                                  <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                  <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                            <td>
                                    <button class="btn btn-warning btn-sm btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit text-white"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button> 
                                    

                                </td>
                              </tr>
                                 `;
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    $('#categoriesTable').append(newTableRowObject);
                    newTableRowObject.fadeIn(3000);
                    toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Başarılı!');
                    placeHolderDiv.find(".modal").modal('hide');
                } else {
                    let summaryText = '<br>';
                    $('#validation-summary > ul > li').each(function () {
                        let liText = $(this).text();
                        summaryText += `*${liText}<br><br>`;
                    });
                    toastr.warning(summaryText, 'Dikkat!');
                }
            });
        });

        //Ajax'la Post işlemleri bitti.



        //Ajax'la DELETE işlemleri
        $(document).on('click', '.btn-delete', function (event) { //claası btn-delete olanlara tıklandığında bu functionı çalıştır.
            event.preventDefault(); //Burada butonumuzun tipi submit olmadığı için bunu kullanmasak da olur.Sadece alışkanlık için
            const id = $(this).attr('data-id'); //hangi sil butonuna tklandıysam onun id'sini alacak.
            Swal.fire({                //Sweetalert.com
                title: 'Silmek istediğinizden emin misiniz?',
                text: "İlgili kategori Silicenektir!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet',
                cancelButtonText: 'Hayır'
            }).then((result) => {
                if (result.isConfirmed) {

                    //Burada kategorinin silinme işlemleri yapılacak. ardından silinmiştir mesajı gösterilecek.
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryId: id },
                        url: '/Admin/Category/Delete/',
                        success: function (data) {
                            const result = jQuery.parseJSON(data);
                            if (result.ResultStatus === 0) {

                                Swal.fire({
                                    title: 'İşlem başarılı!',
                                    text: 'İlgili kategori silinmiştir.',
                                    icon: 'success',
                                    confirmButtonText: 'Tamam'
                                });
                                const tableRow = $(`[name="${id}"]`);
                                tableRow.fadeOut(3000); //fadeout:silinerek çık

                            } else {

                                Swal.fire({
                                    title: 'Hata Oluştu',
                                    text: `${result.Message}`,
                                    icon: 'error',
                                    confirmButtonText: 'Tamam'
                                });
                            }
                        },
                        error: function (err) {

                            toastr.error(err.statusText, 'Hata!');

                        }
                    })

                }
            })
        });

    });
    $(function () {
        const url = '/Admin/Category/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');


        //Category update partial View getirme
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');                //this=tıklanan objei almayı sağlar
            $.get(url, { categoryId: id })
                .done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                })
                .fail(function () {
                    toastr.error('Bir hata oluştu!');
                });
        });
        //category update view getirme bitti.
        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();
            const form = $('#form-category-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend)
                .done(function (data) {
                    const categoryUpdateAjaxModel = jQuery.parseJSON(data);

                    const newFormBody = $('.modal-body', categoryUpdateAjaxModel.CategoryUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';

                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const currentCategoryTableRow = $(` [name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"]`);
                        if (!categoryUpdateAjaxModel.CategoryDto.Category.IsDeleted) {


                            const newTableRow = `
                     <tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Description}</td>
                    <td>${convertFirstLetterToUpperCase(categoryUpdateAjaxModel.CategoryDto.Category.IsActive)}</td>
                    <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.CreatedByName}</td>
                    
                    <td>
                       <button class="btn btn-warning btn-sm btn-update" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-edit text-white"></span></button>
                       <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span></button> 
               
                    </td>
                 </tr>
                    
                 `;
                    const newTableRowObject = $(newTableRow);

                            newTableRowObject.hide();
                            currentCategoryTableRow.replaceWith(newTableRowObject);
                            newTableRowObject.fadeIn(1000);
                            toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, 'İşlem başarılı');

                        } else {
                            currentCategoryTableRow.fadeOut(1000);
                            toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Category.Name} adlı kategori silindi. `, 'İşlem başarılı!')
                        }
                    } else {
                        let summaryText = "<br>";
                        $('#validation-summary > ul >li').each(function () {
                            let text = $(this).text();
                            toastr.error(text); //3 farklı toastr çıkmasını sağlar.
                        });
                        
                    }

                })
        })
    })
});