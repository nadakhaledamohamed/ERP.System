$.validator.setDefaults({
    error: "",
    valid: "",

    highlight: (input, error, valid) => {
        $(input).addClass("is-invalid").removeClass("is-valid");
        $(input.form).find("[data-valmsg-for=" + input.id + "]").addClass("invalid-feedback");
    },

    unhighlight: (input, error, valid) => {
        $(input).addClass("is-valid").removeClass("is-invalid");
        $(input.form).find("[data-valmsg-for=" + input.id + "]").removeClass("invalid-feedback");
    },
});