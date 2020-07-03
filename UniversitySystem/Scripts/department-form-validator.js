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
                            } if (form.checkValidity() === true) {
                                event.preventDefault();

                                var dept = new Object();
                                dept.DepartmentCode = $("#deptCodeInput").val().trim();
                                dept.DepartmentName = $("#deptNameInput").val().trim();

                                $.ajax({
                                    url: "/api/Departments/CreateDepartment",
                                    method: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    data: JSON.stringify(dept),
                                    success: function (response) {
                                        alert(typeof (response));
                                        
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