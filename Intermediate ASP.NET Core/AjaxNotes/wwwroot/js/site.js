$(document).ready(function(){
    $("#newNoteErrors").hide();
    
    //Create a new note.
    $("#submitNote").click(function(e){
        e.preventDefault();
        $.post("note", {title: $("#form_title").val()}, function(data){
            if(data["errors"]){
                $("#newNoteErrors").show();
                handleErrors(data);
            }
            else {
                $("#newNoteErrors").hide();
                $("#newNote").trigger("reset");
                displayNotes(data);
            }
        });
    })

    //Delete a note.
    $("#allNotes").on("click",".delete",function(e){
        let id = $(e.currentTarget).attr('data');
        $.post(`note/${id}/delete`, {id: id}, function(data){
            displayNotes(data);
        });
    });

    //Display form to update note.
    $("#allNotes").on("click","p",function(e){
        let id = $(e.currentTarget).attr('data');
        $(this).parent().html(`
            <div class="form-group">
                <label for="textarea${id}">Note description:</label>
                <textarea id="textarea${id}" class="form-control"></textarea>
            </div>
            <button data="${id}" class="float-right update btn btn-primary">Update</button>
            `);
    });

    //Update a note.
    $("#allNotes").on("click",".update",function(e){
        let id = $(e.currentTarget).attr('data');
        let description = $(`#textarea${id}`).val();
        $.post(`note/${id}`, {description: description}, function(data){
            displayNotes(data);
        });
    });

});

function displayNotes(data) {
    let notes = "";
    for (note of data) {
        let description = note.description;
        if (typeof description == "object"){
            description = "";
        }
        // if (!note.description.Data){
        //     note.description = "";
        // }
        notes += 
        `<div class="note card">
            <div class="card-header">
                <h3 class="float-left">${note.title}</h3>
                <button data=${note.id} class="delete btn btn-danger float-right">Delete</button>
            </div>
            <div class="card-body">
                <p data=${note.id}>${description}</p>
            </div>
        </div>`
    }
    $("#allNotes").html(notes);
}

function handleErrors(data) {
    let messages = "";
    for (let error of data["errors"]){
        messages += `<li class="list-group-item">${error}</li>`
    }
    $("#newNoteErrorList").html(messages);
}