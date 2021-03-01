        tinymce.init({
        selector: '#myTextarea',
        //file_picker_callback: function (callback, value, meta) {
        //    if (meta.filetype == 'image') {
        //        var input = document.getElementById('Resim');
        //        input.click();
        //        input.onchange = function () {
        //            var file = input.files[0];
        //            var reader = new FileReader();
        //            reader.onload = function (e) {
        //                callback(e.target.result, {
        //                    alt: file.name
        //                });
        //            };
        //            reader.readAsDataURL(file);
        //        };
        //    }
        //},
            file_picker_callback: function (callback, value, meta) {
                var input = document.createElement('input');
                input.setAttribute('type', 'file');
                input.setAttribute('accept', 'image/*');
                if (meta.filetype == 'image') {
                    input.click();
                    input.onchange = function () {
                        var file = input.files[0];
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            callback(e.target.result, {
                                alt: file.name
                            });
                        };
                        reader.readAsDataURL(file);
                    };
                }
            },
        file_picker_types: 'file image media',
        images_upload_url: '/Writer/KaydetImage',
        automatic_uploads: true,
        images_upload_base_path: '/wwwroot/',
        images_upload_credentials: true,
        width: 1368,
        height: 768,
        plugins: [
            'advlist autolink link image lists charmap print preview hr anchor pagebreak',
            'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
            'table emoticons template paste help',
            'autoresize'

        ],
        toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | ' +
            'bullist numlist outdent indent | link image | print preview media fullpage | ' +
            'forecolor backcolor emoticons | help',
        menu: {
            favs: { title: 'My Favorites', items: 'code visualaid | searchreplace | emoticons' }
        },
        menubar: 'favs file edit view insert format tools table help',
            //content_css: 'wwwroot\custom\css\tiny\tiny.css',
        relative_urls: true,
            document_base_url: 'https://localhost:44361/',
        remove_script_host: false,
        convert_urls: true,

        image_dimensions: true,
        image_class_list: [
            { title: 'Responsive', value: 'img-responsive' },
            { title: 'Sag', value: 'sag-img-responsive' },
            { title: 'sol', value: 'sol-img-responsive' },
            { title: 'mobil', value: 'mobil-img-responsive' },
            { title: 'full', value: 'full-img-responsive' }
        ]
    });
