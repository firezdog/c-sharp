using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LogReg.Models;

namespace LogReg.Controllers
{
    public class WallController : Controller
    {
        private readonly DbConnector _dbConnector;
        public WallController(DbConnector connect){
            _dbConnector = connect;
        }
        public IActionResult DeleteMessage(int id) {
            try {
                _dbConnector.Execute($"DELETE FROM messages WHERE id={id};DELETE FROM comments WHERE message_id={id}");
            }
            catch {
                Console.WriteLine("Error when deleting.");
            }
            return RedirectToAction("Landing");
        }
        public IActionResult Comment(CommentViewModel comment, int id) {
            var userEmail = HttpContext.Session.GetString("user");
            var user = _dbConnector.Query($"SELECT * FROM users WHERE email='{userEmail}'")[0];
            if(ModelState.IsValid){
                Comment NewComment = new Comment() {
                    commentor_id = (int) user["id"],
                    message_id = id,
                    text = comment.text
                };
                _dbConnector.Execute($"INSERT INTO comments (user_id, message_id, text) VALUES ('{NewComment.commentor_id}','{NewComment.message_id}','{NewComment.text}')");
                return RedirectToAction("Landing");
            }
            var messages = _dbConnector.Query(@"
                SELECT messages.text, messages.created_at, users.first, users.last, messages.id, messages.user_id 
                FROM messages JOIN users ON users.id = messages.user_id
                ORDER BY messages.created_at DESC
            ");
            var comments = _dbConnector.Query(@"
                SELECT comments.text, comments.created_at, users.first, users.last, comments.message_id, comments.user_id FROM comments JOIN users ON users.id = comments.user_id
                ORDER BY comments.created_at DESC
            ");
            ViewBag.user = user;
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            ModelBundle ViewBundle = new ModelBundle { MessageModel = new MessageViewModel(), CommentModel = comment};
            return View("Landing",ViewBundle);
        }
        public IActionResult Message(MessageViewModel message) {
            var userEmail = HttpContext.Session.GetString("user");
            var user = _dbConnector.Query($"SELECT * FROM users WHERE email='{userEmail}'")[0];
            if(ModelState.IsValid){
                Message NewMessage = new Message {
                    user_id = (int) user["id"],
                    text = message.text,    
                };
                _dbConnector.Execute($"INSERT INTO messages (user_id, text) VALUES ('{NewMessage.user_id}', '{NewMessage.text}')");
                return RedirectToAction("Landing");
            }
            var messages = _dbConnector.Query(@"
                SELECT messages.text, messages.created_at, users.first, users.last, messages.id, messages.user_id 
                FROM messages JOIN users ON users.id = messages.user_id
                ORDER BY messages.created_at DESC
            ");
            var comments = _dbConnector.Query(@"
                SELECT comments.text, comments.created_at, users.first, users.last, comments.message_id, comments.user_id FROM comments JOIN users ON users.id = comments.user_id
                ORDER BY comments.created_at DESC
            ");
            ViewBag.user = user;
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            ModelBundle ViewBundle = new ModelBundle { MessageModel = message, CommentModel = new CommentViewModel()};
            return View("Landing",ViewBundle);
        }
        public IActionResult Landing() {
            //Kick out unauthorized users.
            var userEmail = HttpContext.Session.GetString("user");
            if (userEmail == null) {
                return RedirectToAction("Index","Home");
            } else {
                var user = _dbConnector.Query($"SELECT * FROM users WHERE email='{userEmail}'")[0];
                ViewBag.user = user;
            }
            var messages = _dbConnector.Query(@"
                SELECT messages.text, messages.created_at, users.first, users.last, messages.id, messages.user_id 
                FROM messages JOIN users ON users.id = messages.user_id
                ORDER BY messages.created_at DESC
            ");
            var comments = _dbConnector.Query(@"
                SELECT comments.text, comments.created_at, users.first, users.last, comments.message_id, comments.user_id FROM comments JOIN users ON users.id = comments.user_id
                ORDER BY comments.created_at DESC
            ");
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            ModelBundle ViewBundle = new ModelBundle { MessageModel = new MessageViewModel(), CommentModel = new CommentViewModel()};
            return View("Landing",ViewBundle);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
