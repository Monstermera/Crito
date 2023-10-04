 const nameInput = document.getElementById('name');
    const emailInput = document.getElementById('email');
    const messageInput = document.getElementById('message');
    const submitButton = document.getElementById('submitButton');

    function validateName() {
        const nameError = document.getElementById('nameError');
        const nameRegex = /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/;

        if (nameInput.value.length < 2 || !nameRegex.test(nameInput.value)) {
            nameError.innerText = 'Name must be at least 2 characters long and contain only valid characters.';
        } else {
            nameError.innerText = '';
        }
        validateSubmitButton();
    }

    function validateEmail() {
        const emailError = document.getElementById('emailError');
        const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!emailRegex.test(emailInput.value)) {
            emailError.innerText = 'Please enter a valid email address.';
        } else {
            emailError.innerText = '';
        }
        validateSubmitButton();
    }

    function validateMessage() {
        const messageError = document.getElementById('messageError');

        if (messageInput.value.length < 15) {
            messageError.innerText = 'Your message needs to be at least 15 characters long.';
        } else {
            messageError.innerText = '';
        }
        validateSubmitButton();
    }

    function validateSubmitButton() {
        if (
            nameInput.value.length >= 2 &&
            /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/.test(nameInput.value) &&
            /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(emailInput.value) &&
            messageInput.value.length >= 15
        ) {
            submitButton.removeAttribute('disabled');
        } else {
            submitButton.setAttribute('disabled', 'true');
        }
    }