<main>
    <table>
        <tr>
            <td>User Id</td>
            <td>Username</td>
            <td>Full name</td>
        </tr>

        <?php foreach ($this->users as $user) : ?>
            <tr>
                <td><?=htmlspecialchars($user['id'])?></td>
                <td><?=htmlspecialchars($user['username'])?></td>
                <td><?=htmlspecialchars($user['full_name'])?></td>
            </tr>
        <?php endforeach?>
    </table>
</main>