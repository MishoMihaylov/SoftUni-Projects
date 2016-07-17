<?php

class HomeController extends BaseController
{
    function index() {
        
        $posts = $this->model->getLastestPosts(5);
        $this->posts = array_slice($posts, 0, 3);
        $this->postsSideBar = $posts;
    }
	
	function view($id) {
        $post = $this->model->getPostById($id);
        if(sizeof($post) == 0){
            $this->addErrorMessage("Post do not exist");
            $this->redirect("");
        }

        $this->post = $post;
    }
}
