<main>
    <form class="input-form" method="post">
        <div>Title:<input type="text" name="title" value="<?=
            htmlspecialchars($this->post['title'])?>"></div>
        <div>PostId:<input type="text" name="post_id" value="<?=
            htmlspecialchars($this->post['id'])?>" readonly></div>
        <div>Content:<textarea rows="10" name="content"><?=
                htmlspecialchars($this->post['content'])?></textarea></div>
        <div><input type="submit" name="Edit"></div>
    </form>
</main>