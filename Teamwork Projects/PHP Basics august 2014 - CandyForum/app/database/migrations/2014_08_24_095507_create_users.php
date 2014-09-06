<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateUsers extends Migration {

    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        // Creates the users table
        Schema::create('users', function($newtable) 
        {
            $newtable->increments('id');
            $newtable->string('username', 100)->unique();
            $newtable->string('password', 128);            
            $newtable->string('name', 100);
            $newtable->string('last_name', 100);
            $newtable->string('email')->unique();
            $newtable->string('remember_token', 100)->nullable();
            $newtable->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::drop('users');
    }
}