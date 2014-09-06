<!DOCTYPE html>
<html>
<head>
    <title>Candy Forum</title>

    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    
    <link rel="stylesheet" href="{{ asset('./css/reset.css') }}"/>
    <!--<link rel="stylesheet" href="{{ asset('./css/bootstrap.css') }}"/>
    <link rel="stylesheet" href="{{ asset('./css/spacelab.theme.css') }}"/>
    <link rel="stylesheet" href="{{ asset('./jqueryui/jquery-ui.min.css') }}"/>
    <link rel="stylesheet" href="{{ asset('./css/main.css') }}"/> old -->
    <!-- new styles -->
    <link href="{{ asset('./css/font-awesome.css') }}" rel="stylesheet" />
    <link href="{{ asset('./css/css.css') }}" rel="stylesheet" type="text/css">
    <link href="{{ asset('./css/style.css') }}" rel="stylesheet" type="text/css" >

    <script src="{{ asset('./js/jquery-1.11.1.min.js') }}"></script>
    <script src="{{ asset('./js/migrate.js') }}" type="text/javascript"></script>
    <script src="{{ asset('./js/modernizr.js') }}" type="text/javascript"></script>
    <script src="{{ asset('./js/all.js') }}" type="text/javascript"></script>
    <!-- end new styles -->

    <script src="{{ asset('./js/bootstrap.min.js') }}"></script>
    <script src="{{ asset('./js/common.js') }}"></script>
    <script src="{{ asset('./ckeditor/ckeditor.js') }}"></script>
    <script src="{{ asset('./jqueryui/jquery-ui.min.js') }}"></script>
</head>
<body>
    <div class="container">
        <div class="main-container">
            <!-- begin header_container -->
            <div class="header_container_fixed">
                <!-- begin header -->
                <header class="wrapperbpart clearfix">
                    <!-- begin logo -->
                    <div id="headersec" class="headersec section">
                        <div id="Header1" class="widget Header">
                            <div id="header-inner">
                                <a style="display: block" href="/admin">
                                    <img height="100" style="display: block;padding:15px 0px 0px 0px;margin: 0px auto;" src="{{asset ('./css/logo.png')}}" id="Header1_headerimg" alt="CandyForum">
                                </a>
                            </div>
                        </div>
                    </div>
                    <!-- end logo -->

                    <div class="mini_divider"></div>
                    <!-- begin search form -->
                    <div class="search_box">
                        <form action="/posts/show/search" id="searchform" method="post">
                            <input class="field" id="s" name="query" placeholder="Search" type="text">
                        </form>
                    </div>
                    <!-- end search form -->
                    <div class="mini_divider"></div>
                    <!-- begin main navigation -->
                    <div class="menu-mainmenu-container navbpart">
                        <div class="nbttopmenutop section" id="nbttopmenutop">
                            <div class="widget LinkList" id="LinkList7">
                                <div class="widget-content">
                                    <aside class="col-lg-3" id="categories">
                                    <ul class="menu" id="menu-mainmenu">
                                        <li><a href="/posts/show">All</a></li>
                                        <?php $categories = Category::all(); ?>
                                        @foreach($categories as $category)
                                        <li><a href="/posts/show/category/{{ $category->id }}">{{ $category->name }}</a></li>
                                        @endforeach
                                    </ul>                                    
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mini_divider"></div>
                    <!-- end main navigation -->
                </header>
                <!-- end header -->
            </div>
            <!-- end header_container -->
            <!-- begin mainbpart -->
            <div class="mainbpart wrapperbpart clearfix">
                <!-- .main_content-->
                <div class="main_content">
                    <!-- section content -->
                    <div class="contentbpart">
                        <div class="mainblogsec section" id="mainblogsec">
                            <div class="widget Blog" id="Blog1">
                                <div class="blog-posts hfeed">
                                    <!-- google_ad_section_start(name=default) -->
                                    @yield('content')
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- section content -->
                    <!-- begin aside -->
                    <aside>
                        <!-- Sidebar Widgets Area -->
                        <div class="sidebar section" id="sidebartop">
                            <div class="widget HTML" id="HTML1">
                                @if( Auth::check() )
                                    <h2 class="title"><a href="/user/profile/show">{{'Hello, '. Auth::user()->username}}</a></h2>
                                    <div class="widget-content">
                                        <ul>
                                            <li><a href="/posts/create">Add Post</a></li>
                                            <li><a href="/admin/posts/show">All Posts</a></li>
                                            <li><a href="/admin/users">All users</a></li>
                                            <li><a href="/admin/logout">Log out</a></li>
                                        </ul>
                                    </div>
                                @else
                                    <h2 class="title"><a href="/admin/login">Log In</a></h2>
                                @endif
                                <div class="mini_divider"></div>
                                    <h2 class="title">Powered by <a href="http://softuni.bg" target="_blank">Softuni</a> and Team Candytuft</h2>
                                <div class="clear"></div>
                            </div>
                            <!--<div class="widget HTML" id="HTML1">
                                <h2 class="title">Unanswered</h2>
                                <div class="widget-content">
                                    <ul>
                                        <li><a href="">Sample question with comments</a></li>
                                        <li><a href="">This is question 1 </a></li>
                                        <li><a href="">Sample question </a></li>
                                        <li><a href="">Some randoms</a></li>
                                        <li><a href="">Can you answer me</a></li>
                                    </ul>
                                </div>
                                <div class="clear"></div>
                            </div>-->
                        </div>
                        <!-- END Sidebar Widgets Area -->
                    </aside>
                    <!-- end aside -->
                </div>
                <!-- .main_content-->
            </div>
            <!-- end .mainbpart -->
        </div>
        <!-- end #main-container -->
        <!-- begin footer-container -->
        <div class="footer-container">
            <footer class="wrapperbpart">
                <!-- social stuff -->
                <div class="widget" id="social">
                    <a href="mailto:info@yoursite.com"><i class="fa fa-envelope fa-2"></i></a>
                    <a href="#"><i class="fa fa-twitter fa-2"></i></a>
                    <a href="#"><i class="fa fa-dribbble fa-2"></i></a>
                    <a href="#"><i class="fa fa-facebook-square fa-2"></i></a>
                    <a href="#"><i class="fa fa-vimeo-square fa-2"></i></a>
                    <a href="#"><i class="fa fa-linkedin fa-2"></i></a>
                    <a href="#"><i class="fa fa-github fa-2"></i></a>
                    <a href="#"><i class="fa fa-rss fa-2"></i></a>
                </div>
                <!-- end social stuff -->
            </footer>
        </div>
        <!-- end footer-container -->
    </body>
</html>
<!-- old one
        <header class="row">
            <div class="col-lg-12">
                <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand logo" href="/">Candy Forum</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><a href="">test1</a></li>
                            <li><a href="">test2</a></li>
                            <li><a href="">test3</a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            @if( Auth::check() )
                            <li><a href="/user/profile/show">{{'Hello, '. Auth::user()->username}}</a></li>
                            <li><a href="/logout">Log out</a></li>
                            @else
                            <li><a href="/login">Log In</a></li>
                            <li><a href="/register">Register</a></li>
                            @endif
                        </ul>
                    </div>
                </nav>
            </div>
        </header>
    </div>
    <div class="container main-content">
        <main class="row">
            <aside class="col-lg-3" id="categories">
            @if(Auth::check())
            <button type="button" onclick="addPost();">Add Post</button>
            @endif
            <h2>Categories</h2>
            <ul id="categories-list">
                <?php $categories = Category::all(); ?>
                @foreach($categories as $category)
                <li><a href="/posts/show/{{ $category->id }}">{{ $category->name }}</a></li>
                @endforeach
            </ul>
            </aside>
            <section class="col-lg-8">
                @yield('content')
            </section>
        </main>
        <div class="row">
            <h2>Candy Forum footer</h2>
        </div>
    </div>
</body>
</html> -->