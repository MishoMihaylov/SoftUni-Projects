<?php

class UsersModel extends BaseModel
{
    function getUsers(){
        return $statement = SELF::$db->query("SELECT * FROM users")->fetch_all(MYSQLI_ASSOC);
    }

    function login(string $username, string $password)
    {

        if(strlen($username) <= 1){
            $this->addErrorMasage("Username is too short");
        }

        if(strlen($password) <= 1){
            $this->addErrorMasage("Password is too short");
        }

        $statement = SELF::$db->prepare("SELECT username, password_hash, full_name, id FROM users Where username = ?");
        $statement->bind_param("s", $username);
        $statement->execute();

        $result = $statement->get_result()->fetch_assoc();
        if(password_verify($password, $result['password_hash'])){
            return $result['id'];
        }
        
        return false;
    }

    function register(string $username, string $password, string $full_Name)
    {
        $password_hash = password_hash($password, PASSWORD_DEFAULT);
        $statement = SELF::$db->prepare("INSERT INTO users (username, password_hash, full_name) VALUES(? , ?, ?)");
        $statement->bind_param("sss", $username, $password_hash, $full_Name);
        $statement->execute();

        if($statement->affected_rows != 1){
            return false;
        }
        
        $user_id = SELF::$db->query("SELECT LAST_INSERT_ID()")->fetch_row()[0];
        return $user_id;
    }
}
