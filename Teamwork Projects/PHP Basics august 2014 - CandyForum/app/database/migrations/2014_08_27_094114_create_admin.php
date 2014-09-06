<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateAdmin extends Migration {

	/**
	 * Run the migrations.
	 *
	 * @return void
	 */
	public function up()
	{
        Schema::create('admin', function($admin_table){
            $admin_table->increments('id');
            $admin_table->string('username', 100);
            $admin_table->string('password', 128);
            $admin_table->string('remember_token', 100)->nullable();
            $admin_table->timestamps();
        });
	}

	/**
	 * Reverse the migrations.
	 *
	 * @return void
	 */
	public function down()
	{
		Schema::drop('admin');
	}

}
