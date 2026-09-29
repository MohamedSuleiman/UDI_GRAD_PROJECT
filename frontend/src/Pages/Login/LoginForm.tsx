import { Field, Formik, Form } from "formik";
import "./LoginForm.css";

/* Defining the data required for the login form  */
export interface LoginForm {
  email: string;
  password: string;
}
/* Defining the props that the LoginForm component receives*/
interface LoginFormProps {
  onLoginSubmit: (login: LoginForm) => void;
}

function LoginForm({ onLoginSubmit }: LoginFormProps) {
  return (
    <div className="form">
      <h3>Login</h3>

      {/* Handles the form values and form submission */}
      <Formik
        initialValues={{
          email: "",
          password: "",
        }}
        onSubmit={(values) => {
          onLoginSubmit(values);
        }}
      >
        <Form>
          <div className="formFill">
            <label>Email</label>
            <Field
              id="email"
              name="email"
              placeholder="Your Email..."
              type="email"
            />
            <label>Password</label>
            <Field
              id="password"
              name="password"
              placeholder="Your Password..."
              type="password"
            />
          </div>
          <button id="loginButton" type="submit">
            Login
          </button>
        </Form>
      </Formik>
    </div>
  );
}
export default LoginForm;
