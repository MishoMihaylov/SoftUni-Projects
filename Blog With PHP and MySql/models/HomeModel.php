<?php

class HomeModel extends BaseModel
{
    function getLastestPosts($maxCount = 5){
        $statement = SELF::$db->query("SELECT title, content, date, full_name, posts.id FROM posts " .
                  "JOIN users " .
                  "ON users.id=posts.user_id LIMIT " . $maxCount);
        return $statement->fetch_all(MYSQLI_ASSOC);
    }

    function getPostById($id){
        $statement = SELF::$db->prepare("SELECT title, content, date, full_name, posts.id FROM posts "
                                        . "JOIN users "
                                        . "ON posts.user_id=users.id "
                                      . "WHERE posts.id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        $result = $statement->get_result()->fetch_assoc();
        return $result;
    }
    
    function view(){

    }
}
