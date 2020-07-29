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

                                var teachersRemCredits = $("#remCreditOfTeacher").val().trim() -
                                $("#creditOfSelectedCourse").val().trim();

                                $("#remCreditOfTeacher").attr("value", teachersRemCredits);
                                var courseAssigned = $("#coursesDropdown option:selected").val().trim();

                                var courseAssignmentInputs = new Object();

                                courseAssignmentInputs.CourseAssignedDepartment = $("#departmentsDropdown option:selected").val().trim();
                                courseAssignmentInputs.CourseAssignedTeacher = $("#teachersDropdown option:selected").val().trim();
                                courseAssignmentInputs.AssignedCourseId = courseAssigned;
                                courseAssignmentInputs.TeachersRemainingCredit = teachersRemCredits;

                                $.ajax({
                                    url: "/Api/CourseAssignToTeacher/",
                                    method: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    data: JSON.stringify(courseAssignmentInputs),
                                    dataType: "json",
                                    error: function () {
                                        console.log("unable to update");
                                    },
                                    success: function (responseData) {
                                        $("#coursesDropdown option[value=" + responseData + "]").remove();
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