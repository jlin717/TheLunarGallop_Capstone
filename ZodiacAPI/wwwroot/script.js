async function addUser()
{
    const name = document.getElementById('userName').value;
    const year = document.getElementById('birthYear').value;

    const reponse = await fetch('/api/zodiac',
    {
        method: 'POST',
        headers: { 'Content-Type' : 'application/json' },
        body: JSON.stringify({ name : name, birthYear: parseInt(year) })
    });


    //The API returns the user object.
    //Note: Check if your API returns the object or just "Ok()"
    if (reponse.ok)
    {
        const user = await response.json();
        document.querySelector('.zodiac-box').innerHTML =
            `<h2>Hi ${user.Name}!</h2><p>Your sign is the ${user.assignedSign}.</p>`;
    } 
}