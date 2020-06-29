
window.addEventListener('click', Calculate);

function Calculate() {
    const fdAmount = document.getElementById('fdamount').value;
    const rateOfInterest = document.getElementById('roi');
    const maturityAmount = document.getElementById('ma');
    const maturityDate = document.getElementById('md');
    const duration = document.getElementById('Duration');
 
    var today = new Date();
    var date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear()
   
    selectedDuration = duration[duration.selectedIndex].value;
    if (selectedDuration >= 6 && selectedDuration <= 7) {
        let roi = 4;
        rateOfInterest.value =4;
        maturityAmount.value = parseInt(fdAmount) + ((parseInt(fdAmount) * parseInt(rateOfInterest.value) * parseInt(selectedDuration)) / 100);
    }
    else if (selectedDuration >= 8 && selectedDuration <= 12) {
        let roi = 4.5;
        rateOfInterest.value = 4.5;
        maturityAmount.value = parseInt(fdAmount) + ((parseInt(fdAmount) * parseInt(rateOfInterest.value) * parseInt(selectedDuration)) / 100);

    }
    else {
        let roi = 5;
        rateOfInterest.value = 5;
        maturityAmount.value = parseInt(fdAmount) + ((parseInt(fdAmount) * parseInt(rateOfInterest.value) * parseInt(selectedDuration)) / 100);
    }

    let month = parseInt(today.getMonth()) + 1 + parseInt(selectedDuration);
    let year = 0;
    if (month <= 12) {
        month = month;
        year = today.getFullYear();
    }
    else if (month > 12 && month < 18) {
        month = month - 12;
        year = today.getFullYear() + 1;

    }
    else if (month == 18) {
        month = month - 12;
        year = today.getFullYear() + 1

    }
    else if (selectedDuration == 18) {
        month = month - 13;
        year = today.getFullYear() + 1;

    }

    else if (selectedDuration == 24) {
        month = month - 24;
        year = today.getFullYear() + 2;
    }


    
    
    maturityDate.value = today.getDate() + '-' + month + '-' + year;
   
}


