using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace LoginFarmaSteticYj
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        ImageView imageView1;
        EditText txtUser;
        EditText txtPassword;
        Button btnGetInto;
        Button btnRegister;
        Button btnDYFYPassword;

   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            imageView1=FindViewById<ImageView>(Resource.Id.imageView1);
            txtUser=FindViewById<EditText>(Resource.Id.txtUser);
            btnGetInto=FindViewById<Button>(Resource.Id.btnGetInto);
            btnRegister=FindViewById<Button>(Resource.Id.btnRegister);
            btnDYFYPassword=FindViewById<Button>((Resource.Id.btnDYFYPassword));

            btnGetInto.Click += BtnGetInto_Click;
            btnRegister.Click += BtnRegister_Click;
            btnDYFYPassword.Click += BtnDYFYPassword_Click;
        }

        private void BtnDYFYPassword_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BtnRegister_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BtnGetInto_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}