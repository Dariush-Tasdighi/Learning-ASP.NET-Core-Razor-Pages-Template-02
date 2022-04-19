$(function () {

	$('form').submit(function (e) {

		if ($(this).valid()) {

			$('button').prop('disabled', true)
			$('input[type=button]').prop('disabled', true)

		}

	})

})
