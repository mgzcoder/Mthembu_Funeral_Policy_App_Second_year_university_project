
    function Response() {
            var x = document.getElementById("myTopnav");
            if (x.className === "topnav") {
        x.className += " responsive";
            } else {
        x.className = "topnav";
            }
        }

        function openFormSignup() {
        document.getElementById("sign-up_form").style.display = "block";
        }
    