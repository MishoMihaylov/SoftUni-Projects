<?php $this->title = 'Welcome to My Blog'; ?>

<h1><?=htmlspecialchars($this->title)?></h1>

<aside>
    <h2>Recent Posts</h2>
    <?php
    foreach ($this->postsSideBar as $currPost){
        $route = APP_ROOT . '/home/view/' . $currPost['id']; ?>
        <a href="<?=$route?>"><?=$currPost['title']?></a>
    <?php
    }
    ?>
</aside>

<main>
    <?php
    foreach ($this->posts as $currPost){
        echo '<h1>' . htmlentities($currPost['title']) . '</h1>';
        echo '<p><i> Written by ' . htmlentities($currPost['full_name']) . ' on '
            . htmlentities($currPost['date']) . '</i></p>';
        echo '<p>' . htmlentities($currPost['content']) . '</p>';
    }
    ?>
</main>

