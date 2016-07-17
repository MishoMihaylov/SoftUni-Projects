<h1><?=htmlentities($this->post['title'])?></h1>

<main>
    <?php
        echo '<p><i> Written by ' . htmlentities($this->post['full_name']) . ' on '
            . htmlentities($this->post['date']) . '</i></p>';
        echo '<p>' . htmlentities($this->post['content'], ENT_HTML5) . '</p>';
    ?>
</main>