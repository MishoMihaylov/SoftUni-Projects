<?php

class UsersController extends BaseController
{
    function index()
    {
        if($this->model->getUsers()){
            $this->users = $this->model->getUsers();
            //var_dump($this->model->getUsers());
        }else{
            $this->addErrorMessage("Error on loading users");
            $this->redirect("");
        }
    }

    public function register()
    {
		if($this->isPost){
            $username = $_POST['username'];
            $password = $_POST['password'];
            $password_confirm = $_POST['password_confirm'];
            $full_name = $_POST['full_name'];

            if(strlen($username) <= 3){
                $this->setValidationError("username", "Invalid username");
            }

            if(strlen($password) <= 3){
                $this->setValidationError("password", "Invalid password");
            }

            if($password !== $password_confirm){
                $this->setValidationError("password_confirm", "Password do not match");
            }

            if($this->formValid()) {
                $user_id = $this->model->register($username, $password, $full_name);
                if ($user_id !== false) {
                    $_SESSION['username'] = $username;
                    $_SESSION['user_id'] = $user_id;
                    $this->addInfoMessage("Registration completed");
                    $this->redirect("");
                } else {
                    $this->addErrorMessage("Error: Registration failed");
                }
            }
        }
    }

    public function login()
    {
        if($this->isPost){
            $username = $_POST['username'];
            $password = $_POST['password'];

            $user_id = $this->model->login($username, $password);

            if($user_id !== false){
                $_SESSION['username'] = $username;
                $_SESSION['user_id'] = $user_id;
                $this->addInfoMessage("Login completed");
                $this->redirect("");
            }else{
                $this->addErrorMessage("Error: Login failed");
            }
        }
    }

    public function logout()
    {
		session_destroy();
        $this->redirect("");
    }
}
