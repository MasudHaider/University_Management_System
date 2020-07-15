(function () {
    'use strict';
    window.addEventListener('load',
        function () {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.getElementsByClassName("form-needs-validation");
            // Loop over them and prevent submission
            var validation = Array.prototype.filter.call(forms,
                function (form) {
                    form.addEventListener('submit',
                        function (event) {
                            if (form.checkValidity() === false) {
                                event.preventDefault();
                                event.stopPropagation();
                            }
                            else {
                                event.preventDefault();

                                var teacherInputs = new Object();
                                teacherInputs.TeacherName = $("#teacherNameInput").val().trim();
                                teacherInputs.TeacherAddress = $("#teacherAddressInput").val().trim();
                                teacherInputs.TeacherEmail = $("#teacherEmailInput").val().trim();
                                teacherInputs.TeacherContactNumber = $("#teacherContactInput").val().trim();
                                teacherInputs.SelectedDesignationId = $("#selectedDesignationId option:selected").val().trim();
                                teacherInputs.SelectedTeacherDepartmentId = $("#selectedTeacherDepartmentId option:selected").val().trim();
                                teacherInputs.TeacherCredits = $("#teacherCreditInput").val().trim();

                                $.ajax({
                                    url: "/Api/Teachers/CreateTeacher",
                                    method: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    data: JSON.stringify(teacherInputs),
                                    dataType: "json",
                                    success: function (response) {
                                        console.log((response.length));
                                    }
                                });
                            }
                            form.classList.add('was-validated');
                        },
                        false);
                });
        },
        false);
})();