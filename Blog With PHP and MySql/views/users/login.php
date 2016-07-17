<?php $this->title = 'Login'; ?>

<h1><?= htmlspecialchars($this->title) ?></h1>

<form class="input-form" method="post">
    <div>Username: <input type="text" name="username" required></div>
    <div>Password: <input type="password" name="password" required></div>
    <div><input type="submit" value="Login"></div>
</form>
