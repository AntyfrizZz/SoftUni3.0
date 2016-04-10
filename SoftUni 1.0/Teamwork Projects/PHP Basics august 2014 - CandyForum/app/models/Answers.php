<?php
class Answers{
    public static  function allAnswers($id){
        $answers = Answer::where('post_id', '=', $id)->get();
        return $answers;
    }
}