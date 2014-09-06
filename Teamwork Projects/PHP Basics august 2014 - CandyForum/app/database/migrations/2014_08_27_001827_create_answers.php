<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateAnswers extends Migration {

	/**
	 * Run the migrations.
	 *
	 * @return void
	 */
	public function up()
	{
        Schema::create('answers', function($answer_table){
            $answer_table->increments('id');
            $answer_table->string('author', 100);
            $answer_table->string('content', 300);
            $answer_table->integer('post_id');
            $answer_table->integer('author_id');
            $answer_table->timestamps();
        });
	}

	/**
	 * Reverse the migrations.
	 *
	 * @return void
	 */
	public function down()
	{
		Schema::drop('answers');
	}

}
