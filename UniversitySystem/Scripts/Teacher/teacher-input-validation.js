$(document).ready(function () {
    //setup before functions
    var typingTimer;                //timer identifier
    var doneTypingInterval = 1500;  //time in ms, 3 seconds

    const inputFields = {
        teacherNameInput: /^[A-Za-z]+$/,
        teacherAddressInput: /^[A-Za-z\d]{3,30}$/,
        teacherEmailInput: /^\w+([\.-]?\w+)*@[A-Za-z]+([\.-]?\w+)*(\.\w{2,4})+$/,
        teacherContactInput: /^\d{11}$/,
        teacherCreditInput: /^\d{1,2}(\.\d{0,2})?$/
    }

    const validateFields = (field, regex) => {
        var errorTag = field.nextElementSibling;
        errorTag.removeAttribute();
        regex.test(field.value) ? field.className = 'valid' : field.className = 'invalid';
    }

    //$("input").keyup(function(event) {
    //    clearTimeout(typingTimer);
    //    setTimeout(() => validateFields(event.target, inputFields[e.target.attributes.id.value]));
    //});

    const keys = document.querySelectorAll('input');
    keys.forEach(item => item.addEventListener(
        'keyup', e => {
            clearTimeout(typingTimer);
            setTimeout(() => validateFields(e.target, inputFields[e.target.attributes.id.value]),
                doneTypingInterval);
        }
    ));

    //on keydown, clear the countdown
    $(":input").on('keydown', function () {
        clearTimeout(typingTimer);
    });
});