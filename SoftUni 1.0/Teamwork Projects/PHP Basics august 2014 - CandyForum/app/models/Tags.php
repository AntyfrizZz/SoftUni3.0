<?php
class Tags{
public static function getTags(){
    $tagObject = Tag::all();
    $tags = array();
    foreach($tagObject as $tag){
        $tags[] = $tag['original']['name'];
    }
    return $tags;
}
}