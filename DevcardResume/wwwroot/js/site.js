﻿"use strict";
/* ==== Vanilla JS Back To Top Widget ====== */
/* Ref: https://github.com/vfeskov/vanilla-back-to-top */
addBackToTop({
	cornerOffset: 15, // px
	id: 'back-to-top',
});

$("form").on("change", ".file-upload-field", function () {
	$(this).parent(".file-upload-wrapper").attr("data-text", $(this).val().replace(/.*(\/|\\)/, ''));
});