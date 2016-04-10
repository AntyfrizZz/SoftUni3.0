<?php
class Posts{
    public static function  allPosts($id = -1, $flag = ''){
        if($id == -1){
            $posts = Post::orderBy('created_at', 'DESC')->get();
        }
        else {
            $posts = Post::where('id', '=', $id)->get();
        }
        if($flag == 'category')
        {
            $posts = Post::where('category_id', '=', $id)->get();
        }
        else if($flag == 'user')
        {
            $posts = Post::where('author_id', '=', $id)->get();
        }
        $result = array();
        $count = 0;
        foreach($posts as $post){
            $result[] = $post['original'];
            if(!isset($result[$count]['author']))
            {
                $result[$count]['author'] = '';
            }
            if(!isset($result[$count]['category']))
            {
                $result[$count]['category'] = '';
            }
            $result[$count]['author'] = User::where('id', '=', $result[$count]['author_id'])->get()->first()['original']['username'];
            $result[$count]['category'] = Category::where('id', '=', $result[$count]['category_id'])->get()[0]['name'];
            unset($result[$count]['']);
            $count += 1;
        }
        return $result;
    }
}