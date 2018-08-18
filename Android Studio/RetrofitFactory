package com.hexavara.hexavarademo.API;


import java.io.IOException;
import java.util.concurrent.TimeUnit;

import okhttp3.HttpUrl;
import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

    public class ApiFactory {
        private static final String url = "http://hexavara.ip-dynamic.com/androidrec/public/api/";
        private static final String myAPIKey = "d4bd67cc5051492dab6b86420da763e4";

        /**
         * create retrofit object based
         *
         * @param t Class of T
         * @return
         */
        public <T> T create(Class<T> t) {
            return getRetrofit().create(t);
        }


        /**
         * Get retrofit build
         * @return Retrofit
         */
        public Retrofit getRetrofit() {
            return getRetrofit(url);
        }

        /**
         * @param url
         * @return Retrofit
         */
        public Retrofit getRetrofit(String url) {
            return new Retrofit.Builder()
                    .baseUrl(url)
                    .addConverterFactory(GsonConverterFactory.create())
                    .client(getHttpConfiguration())
                    .build();
        }


        /**
         * @return OkHttpClient
         */
        public OkHttpClient getHttpConfiguration() {

            int connectTimeOutMS = 2000;
            int readTimeOutMS = 2000;
            HttpLoggingInterceptor interceptor = new HttpLoggingInterceptor();
            interceptor.setLevel(HttpLoggingInterceptor.Level.BODY);

            OkHttpClient client = new OkHttpClient.Builder()
                    .addInterceptor(new Interceptor() {
                        @Override
                        public Response intercept(Chain chain) throws IOException {
                            Request newRequest = chain.request();
                            HttpUrl originalHttpUrl = newRequest.url();

                            HttpUrl _url = originalHttpUrl.newBuilder()
                                    .addQueryParameter("apiKey", myAPIKey)
                                    .build();

                            newRequest.newBuilder().url(_url).build();
                            return chain.proceed(newRequest);
                        }
                    })
                    .addInterceptor(interceptor)
                    .connectTimeout(connectTimeOutMS, TimeUnit.SECONDS)
                    .readTimeout(readTimeOutMS, TimeUnit.SECONDS)
                    .build();
            return client;
        }
    }



