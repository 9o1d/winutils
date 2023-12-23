<?php
$s_file_name = "/path/to/status.txt";
if (isset($_GET['i']))
{
	$i = intval($_GET['i']);
	file_put_contents($s_file_name, $i);
	echo $i;
}
else
{
	$s = @file_get_contents($s_file_name);
	if (!empty($s))
	{
		echo intval($s);
		file_put_contents($s_file_name, "0");
	}
	else
	{
		echo 0;
	}
}
?>
