<?php

class PostsModel extends BaseModel
{
    
    function getPost($id){
        $statement = SELF::$db->prepare("SELECT * FROM posts WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();

        $result = $statement->get_result()->fetch_assoc();
        if(!$result){
            return false;
        }
        return $result;
    }

    function getAllPosts()
    {
        $statement = SELF::$db->query("SELECT title, content, date, full_name, posts.id, posts.user_id FROM posts "
                                        . "JOIN users "
                                        . "ON posts.user_id=users.id ");
        $result = $statement->fetch_all(MYSQLI_ASSOC);
        return $result;
    }

    function createPost($title, $content, $user_id){

        $statement = SELF::$db->prepare("INSERT INTO posts (user_id, title, content, date) "
                                        . "VALUES (?, ?, ?, CURDATE())");
        $statement->bind_param("sss", $user_id, $title, $content);
        $statement->execute();
        
        if($statement->affected_rows != 1){
            return false;
        }
        
        return true;
    }

    function editPost($id, $title, $content){

        $statement = SELF::$db->prepare("UPDATE posts "
                                        ."SET "
                                        ."title = ?, "
                                        ."content = ? "
                                        ."WHERE id = ?");
        $statement->bind_param("ssi", $title, $content, $id);
        $statement->execute();

        $_SESSION['affectedRows'] = $statement->affected_rows;
        if($statement->affected_rows != 1){
            return false;
        }
        return true;
    }
    
    function removePost(int $id) : bool
    {
        $statement = SELF::$db->prepare("DELETE FROM posts WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        
        if($statement->affected_rows != 1){
            return false;
        }
        
        return true;
    }

}
