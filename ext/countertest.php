<?php
if ( ! defined( 'ABSPATH' ) ) {
	exit;
}
/*
Ecrire les sessions dans le txt
*/
$current_users_file = 'ct/users.txt';
if (!file_exists($current_users_file)) fclose(fopen($current_users_file, "w"));
$users = file($current_users_file);
$found = false;
$user_count = count($users);
$fp = fopen($current_users_file, "w");
$id = substr(session_id(), 0, -15);;
//$trimedid = substr($id, 0, -10);
/*
if (session_status() == PHP_SESSION_ACTIVE) {
  echo 'Session is active';
}
else {
	echo 'no session';
}
*/
foreach($users as $user) {
    $user = explode("|", $user);
    if ($user[1]+80 < time()) {
        $user_count--;
        continue;
    } elseif ($user[0] == $id) {
        $user[1] = time();
        $found = true;
    }
    $user = trim(implode("|", $user))."\n";
    fputs($fp, $user);
}
if (!$found) {
    fputs($fp, $id."| ".time()."\n");
    $user_count++;
}
fclose($fp);

$printtamere = 'Active users <b>' . $user_count . '</b>' ;

   // echo "<script>console.debug( \"PHP DEBUG: $printtamere\" );</script>";
?>
<div id="opki" style="display:none;"><?php echo $user_count; ?></div>
