<?php
if ( ! defined( 'ABSPATH' ) ) {
	exit;
}
if (preg_match('/bot|crawl|curl|dataprovider|search|get|spider|find|java|majesticsEO|google|yahoo|teoma|contaxe|yandex|libwww-perl|facebookexternalhit/i', $_SERVER['HTTP_USER_AGENT'])) {
    // is bot
}
else {
	
	$current_users_file = 'ct/users.txt';
if (!file_exists($current_users_file)) fclose(fopen($current_users_file, "w"));
$users = file($current_users_file);
$found = false;
$user_count = count($users);
$fp = fopen($current_users_file, "w");
$id = substr(session_id(), 0, -15);;


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
	//last user was written date("i:s") ago
	
}
fputs($fp, "last=".date("Y,m,d,H,i,s"));
fclose($fp);
}

?>
<div id="opki" style="display:none;"><?php echo $user_count; ?></div>
