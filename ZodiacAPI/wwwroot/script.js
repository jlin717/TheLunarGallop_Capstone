const API_URL = '/api/zodiac';

// CREATE — POST a new user to the API
async function addUser() {
    const nameVal = document.getElementById('userName').value;
    const yearVal = document.getElementById('birthYear').value;

    if (!nameVal || !yearVal) {
        alert("Please fill in your details!");
        return;
    }

    try {
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: nameVal, birthYear: parseInt(yearVal) })
        });

        if (response.ok) {
            const user = await response.json();

            document.getElementById('result-display').innerHTML = `
                <div class="result-card">
                    <h3>Hi, ${user.name}!</h3>
                    <p>Birth Year: <strong>${user.birthYear}</strong></p>
                    <p>Your Zodiac Sign: <strong>${user.assignedSign}</strong></p>
                    <p>Your Lucky Flower: <strong>${user.luckyFlower}</strong></p>
                    <p><em>${user.description}</em></p>
                </div>
            `;

            loadUsers();

        } else {
            alert("Error: The server couldn't process your request.");
        }
    } catch (error) {
        console.error("Connection failed:", error);
        alert("Make sure your C# project is running!");
    }
}

async function loadUsers() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) throw new Error("Failed to load users.");

        const users = await response.json();
        const tbody = document.getElementById('users-tbody');

        if (users.length === 0) {
            tbody.innerHTML = '<tr><td colspan="7">No journeys saved yet.</td></tr>';
            return;
        }

        tbody.innerHTML = users.map(u => `
            <tr>
                <td>${u.id}</td>
                <td>${u.name}</td>
                <td>${u.birthYear}</td>
                <td>${u.assignedSign}</td>
                <td>${u.luckyFlower}</td>
                <td style="font-size:0.85em">${u.description}</td>
                <td>
                    <button class="action-btn secondary" onclick="startEdit(${u.id}, '${u.name}', ${u.birthYear})">Edit</button>
                    <button class="action-btn danger" onclick="deleteUser(${u.id})">Delete</button>
                </td>
            </tr>
        `).join('');

    } catch (error) {
        console.error("Error loading users:", error);
    }
}

function startEdit(id, name, birthYear) {
    document.getElementById('editUserId').value = id;
    document.getElementById('editUserName').value = name;
    document.getElementById('editBirthYear').value = birthYear;
    document.getElementById('edit-section').style.display = 'block';
    document.getElementById('edit-section').scrollIntoView({ behavior: 'smooth' });
}

async function submitEdit() {
    const id = document.getElementById('editUserId').value;
    const name = document.getElementById('editUserName').value;
    const birthYear = parseInt(document.getElementById('editBirthYear').value);

    if (!name || !birthYear) {
        alert("Please fill in both fields.");
        return;
    }

    try {
        const response = await fetch(`${API_URL}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name, birthYear })
        });

        if (response.ok) {
            cancelEdit();
            loadUsers();
        } else {
            alert("Error updating user.");
        }
    } catch (error) {
        console.error("Update failed:", error);
        alert("Make sure your C# project is running!");
    }
}

function cancelEdit() {
    document.getElementById('edit-section').style.display = 'none';
    document.getElementById('editUserId').value = '';
    document.getElementById('editUserName').value = '';
    document.getElementById('editBirthYear').value = '';
}

async function deleteUser(id) {
    if (!confirm("Are you sure you want to delete this journey?")) return;

    try {
        const response = await fetch(`${API_URL}/${id}`, { method: 'DELETE' });

        if (response.ok) {
            loadUsers();
        } else {
            alert("Error deleting user.");
        }
    } catch (error) {
        console.error("Delete failed:", error);
        alert("Make sure your C# project is running!");
    }
}

document.addEventListener('DOMContentLoaded', () => {
    // Wire up the main form button
    document.getElementById('revealBtn').addEventListener('click', addUser);

    // Wire up the Refresh button
    document.getElementById('refreshBtn').addEventListener('click', loadUsers);

    // Wire up the Edit form buttons
    document.getElementById('saveEditBtn').addEventListener('click', submitEdit);
    document.getElementById('cancelEditBtn').addEventListener('click', cancelEdit);

    // Load the saved users table on page open
    loadUsers();
});
