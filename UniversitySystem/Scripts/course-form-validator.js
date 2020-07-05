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
                            if (form.checkValidity() === true) {
                                event.preventDefault();

                                var courseInputs = new Object();
                                courseInputs.CourseCode = $("#courseCodeInput").val().trim();
                                courseInputs.CourseName = $("#courseNameInput").val().trim();
                                courseInputs.CourseCredit = $("#courseCreditInput").val().trim();
                                courseInputs.CourseDescription = $("#courseDescriptionInput").val().trim();
                                courseInputs.SelectedDepartmentId = $("#selectedDepartmentId option:selected").val().trim();
                                courseInputs.SelectedSemesterId = $("#selectedSemesterId option:selected").val().trim();

                                $.ajax({
                                    url: "/Api/Courses/CreateCourse",
                                    method: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    data: JSON.stringify(courseInputs),
                                    success: function (response) {
                                        alert(response.length);
                                    }
                                    /*error: function () {
                                        alert('failed');
                                    }*/
                                });
                            }
                            form.classList.add('was-validated');
                        },
                        false);
                });
        },
        false);
})();