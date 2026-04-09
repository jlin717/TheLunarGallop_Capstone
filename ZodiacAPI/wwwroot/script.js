async function addUser() {
    const nameVal = document.getElementById('userName').value;
    const yearVal = document.getElementById('birthYear').value;

    if (!nameVal || !yearVal) {
        alert("Please enter your name and birth year!");
        return;
    }

    const response = await fetch('/api/zodiac', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: nameVal, birthYear: parseInt(yearVal) })
    });

    if (response.ok) {
        const user = await response.json();
        
        // Update the display with BOTH the Sign and the Flower
        document.getElementById('result-display').innerHTML = `
            <h3>Hi ${user.name}!</h3>
            <p>You were born in the year of the <strong>${user.assignedSign}</strong>.</p>
            <p>Your Auspicious Flora is the <strong>${user.luckyFlower}</strong>!</p>
        `;
    } else {
        alert("Server error. Is the API running?");
    }
}