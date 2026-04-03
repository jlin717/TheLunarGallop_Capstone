using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZodiacAPI.Models;

namespace ZodiacAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ZodiacController : ControllerBase
{
    private static List<UserProfile> Signs = new List<UserProfile>
    {
        new UserProfile {Id = 1, Name = "Rat", Description = "Ambitious, clever and devoted to their family. Hard-working and imaginative. Not always sure of themselves and do not always plan for the future. Will always stand by their friends."},
        new UserProfile {Id = 2, Name = "Ox", Description = "Born leaders who will work hard to achieve their aims. Dependable, good organisers and not easily influenced by others. Patient, loyal to their friends and expect loyalty in return. Tend to have lasting relationships."},
        new UserProfile {Id = 3, Name = "Tiger", Description = "Sensitive, emotional and adventurous. Confident, risk takers and dislike taking orders. Good at seeing problems, but less able to see the solutions. Often seek a shoulder to cry on when feeling down. Warm and generous to the people they love."},
        new UserProfile {Id = 4, Name = "Rabbit", Description = "Affectionate, gentle with strong family ties. Caring and hates conflict. Peace-makers with lots of friends. Dislike being the centre of attention and enjoy the good things of life."},
        new UserProfile {Id = 5, Name = "Dragon", Description = "Confident, hardworking and always strive to be at the top. Full of energy, determined and will inspire other people. Don't like routine and are excited by new projects. Show loyalty to friends, popular and fun-loving. The Dragon is the only mythical creature in the Chinese zodiac and is looked upon as the luckiest of all the animals."},
        new UserProfile {Id = 6, Name = "Snake", Description = "Charming and good thinkers. Love the finer things in life, so only the best is good enough. Good at making and saving money. Patient, charming and wise. Prefer not to rely on other people."},
        new UserProfile {Id = 7, Name = "Horse", Description = "Very hardworking and independent. Will work on and on until a job is finished. Very intelligent, ambitious and expect to succeed. Can cope with several projects at once. Easily fall in love."},
        new UserProfile {Id = 8, Name = "Goat", Description = "Elegant, artistic and good-natured. Inclined to worry too much. Peace-lovers who prefer to avoid disagreements. Others may put upon them, but they are stronger than they seem. Family is very important."},
        new UserProfile {Id = 9, Name = "Monkey", Description = "Very clever, but mischievous. Love a challenge and can wriggle out of difficult situations by thinking through difficult problems. Highly successful and well-liked."},
        new UserProfile {Id = 10, Name = "Rooster", Description = "Hardworking, strong-willed and confident. Well organised and good time keepers. Enjoy being the centre of attention and love flattery. Often outspoken and hate criticism of themselves though they can be inclined to find fault with other people."},
        new UserProfile {Id = 11, Name = "Dog", Description = "Faithful, honest and ready to serve others. Believe in truth and justice and loyal to friends. Always willing to listen to people's problems and is able to gain the respect of others. Will share their thoughts but do not easily forgive those who cross them. Trustworthy. Tend to worry too much."},
        new UserProfile {Id = 12, Name = "Pig", Description = "Honest, peace-loving and make good friends. Will try not to argue and rarely lose their temper. Love the good things in life and are very willing to share with others. Enjoy gossip and fall in love easily. Can be untidy people at home."}
    };

    private static List<UserProfile> Users = new List<UserProfile>();

    [HttpGet] //Read: Get all users
    public ActionResult<IEnumerable<UserProfile>> Get() => Ok(Users);
    
    [HttpPost] //Create: Add a user and calculates their sign
    public IActionResult PostUser([FromBody] UserProfile newUser)
    {
        int signIndex = (newUser.BirthYear - 4) % 12;
        if (signIndex < 0) signIndex += 12;

        newUser.AssignedSign = Signs[signIndex].Name;
        newUser.Id = Users.Count + 1;

        Users.Add(newUser);
        return Ok();
    }

    [HttpPut("{id}")] //Update: Fix a name or year
    public IActionResult UpdateUser(int id, [FromBody] UserProfile updated)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        user.Name = updated.Name;
        user.BirthYear = updated.BirthYear;

        //Recalculates the year in case it changes
        int signIndex = (updated.BirthYear - 4) % 12;
        user.AssignedSign = Signs[signIndex].Name;

        return Ok(user);
    }

    [HttpDelete("{id}")] //Delete: Remove user
    public IActionResult DeleteUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        Users.Remove(user);
        return Ok();
    }
}