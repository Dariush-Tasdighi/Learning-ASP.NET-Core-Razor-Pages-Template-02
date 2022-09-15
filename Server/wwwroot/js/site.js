$(function () {

	$('form').submit(function (e) {

		if ($(this).valid()) {

			$('button').prop('disabled', true)
			$('input[type=button]').prop('disabled', true)

		}

	})

})


//------------------------- TINY MCE---------------------------------------------------

		tinymce.init({
			skin: 'oxide',
			selector: '.tinymce',
			language: 'fa',
			plugins: 'image code link save table wordcount emoticons directionality insertdatetime nonbreaking pagebreak searchreplace visualblocks',
			toolbar: 'undo redo | link image | code table | save searchreplace | bold italic underline | bullist numlist | blockquote quicklink | blocks | alignleft aligncentre alignright alignjustify | indent outdent | bullist numlist',

		});

//----------------------------------------------------------------------------------
