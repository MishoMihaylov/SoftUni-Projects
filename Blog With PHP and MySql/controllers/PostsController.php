<?php

class PostsController extends BaseController
{
    public function onInit()
    {
        $this->authorize();
    }

    public function index(){
        $this->posts = $this->model->getAllPosts();
    }

    public function create(){
        if($this->isPost) {
            $user_id = $_SESSION['user_id'];
            $title = $_POST['title'];
            $content = $_POST['content'];

            if (strlen($title) < 3) {
                $this->setValidationError("title", "Invalid title");
            }

            if (strlen($content) < 10) {
                $this->setValidationError("content", "Invalid content");
            }

            if($this->formValid()) {
                $result = $this->model->createPost($title, $content, $user_id);
                if (!$result) {
                    $this->addErrorMessage("Post couldn't be created");
                } else {
                    $this->addInfoMessage("Post was created");
                }

                $this->redirect("posts", 'index');
            }
        }
    }

    public function edit($id){

        if($this->isPost){
            $postId = $_POST['post_id'];
            $title = $_POST['title'];
            $content = $_POST['content'];

            $result = $this->model->editPost($postId, $title, $content);
            
            if($result != 0 && $result != 1){
                $this->addErrorMessage("Post couldn't be edited" );
                var_dump($_SESSION['affectedRows']);
            }else{
                $this->addInfoMessage("Post was edited");
            }

            $this->redirect("posts", 'index');
        }else{
            //$id = explode('/', $_SERVER['REQUEST_URI'])[4];
            $this->post = $this->model->getPost($id);
        }
    }

    public function delete($id){
        //$id = explode('/', $_SERVER['REQUEST_URI'])[4];
        $isRemoved = $this->model->removePost($id);

        if($isRemoved){
            $this->addInfoMessage("Post removed");
        }else{
            $this->addErrorMessage("Post could't be removed");
        }

        $this->redirect("posts", 'index');
    }
}
