import React, { Component } from 'react';
import { ScrollView, StyleSheet, Picker } from 'react-native';
import { TextInput } from 'react-native-paper';
import { Button } from 'react-native-paper';
import { Image, View } from 'react-native';
import { ImagePicker } from 'expo';
import { ToggleButton } from 'react-native-paper';
import { Divider } from 'react-native-paper';
import { Surface } from 'react-native-paper';
import { WebView, Switch } from 'react-native';
import { Modal, Text, Provider } from 'react-native-paper';
import { Searchbar, Card, Title, Paragraph } from 'react-native-paper';
import { Constants, Location, Permissions } from 'expo';





export default class Create extends React.Component {
  static navigationOptions = {
    title: 'Create new Vibe',
  };

  state = {
    status: 'checked',
    title: '',
    message: '',
    image: 'https://picsum.photos/200/300/?blur=7',
    secret: '',
    type: 'other',
    isEncrypted: false,
    visible: false,
    preview: false,
    buttonText: true,
    location: null,
    errorMessage: null,
    latitude : null,
    longitude : null,
    base64StringVar : '',

  };





  _showDialog = () => this.setState({ visible: true });
  _hideDialog = () => this.setState({ visible: false });

   componentWillMount() {
      this._getLocationAsync();
  }

  _getLocationAsync = async () => {
    let { status } = await Permissions.askAsync(Permissions.LOCATION);
    if (status !== 'granted') {
      this.setState({
        errorMessage: 'Permission to access location was denied',
      });
    }

    let location = await Location.getCurrentPositionAsync({});
    this.setState({ location });
    this.setState({ latitude : location.coords.latitude, longitude : location.coords.longitude })
  };


  render() {
    let { image } = this.state;
    const { isEncrypted } = this.state;  

    return (
      <View style={styles.container}>
      {this.state.preview &&
      <View style={styles.container}>
      <ScrollView >

      <View>


      <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>{this.state.title}</Title>
          <Paragraph>{this.state.message}</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: image }} />
        <Text>Location: {this.state.latitude},{this.state.longitude}</Text>
       </Card>

      </View>
      <Divider />

      <View style={styles.bottomContainer}>
      <Text> Slide the moneyButton to upload your Vibe! </Text>
      <Text> [Base 64 Image uploads are currently inactive] </Text>
      <WebView
        source={{uri: 'https://firebasestorage.googleapis.com/v0/b/spatialmap-1b08e.appspot.com/o/MetaVibe%2Fmbtn_adapter.html?alt=media&token=4c4174e6-4a91-4669-8ee4-7482f39146cf&opcode=MetaVibe2_' + this.state.title + '_' + this.state.message + '_' + this.state.type + '_' + this.state.latitude + '_' + this.state.longitude}}
        style={{height: 200}}
      /> 
      </View>
      </ScrollView>

      </View>
      }

      {!this.state.preview &&
      <ScrollView >

      <TextInput
        style={{backgroundColor: 'white', margin: 5}}
        label='Title'
        value={this.state.title}
        onChangeText={title => this.setState({ title })}
      />

      <TextInput
        multiline={true}
        style={{backgroundColor: 'white', margin: 5}}
        label='Message / Text'
        value={this.state.message}
        onChangeText={message => this.setState({ message })}
      />

      <Picker
        selectedValue={this.state.type}
        prompt='Event Type'
        style={{height: 50, width: '100%', margin: 5}}
        onValueChange={(itemValue, itemIndex) =>
          this.setState({type: itemValue})
        }>
        <Picker.Item label="Other" value="other" />
        <Picker.Item label="Event" value="event" />
        <Picker.Item label="Message" value="message" />
        <Picker.Item label="Meetup" value="meetup" />
        <Picker.Item label="Sports" value="sports" />
        <Picker.Item label="Media" value="media" />
      </Picker>
      <Divider style={{marginLeft: 5, marginRight: 5, marginBottom: 5, color: '#000'}}/>
        
      
      <View style={styles.container2}>
      <Text>
      Location Specific Access
      </Text>
       <Switch
        value={isEncrypted}
        onValueChange={() =>
          { this.setState({ isEncrypted: !isEncrypted }); }
       }
      />
      </View>

      <Divider style={{marginLeft: 5, marginRight: 5, marginBottom: 5, color: '#000'}}/>
      
      <Button icon="add-a-photo" style={{padding: 5, margin: 5, backgroundColor: 'rgba(0,100,150,0.8)'}} mode="contained" onPress={this._pickImage}>
        Upload Event Picture
      </Button>
      <View style={{ alignItems: 'center', justifyContent: 'center' }}>

      {image &&
        <Image source={{ uri: image }} style={{ width: 400, height: 225 }} />}
      </View>
      </ScrollView>
      }

      <View style={{backgroundColor: 'rgba(0,0,0,0.05)'}}>
      <Surface style={styles.surface}>
      <Divider />
       <Button style={{margin: 5, padding: 5, backgroundColor: 'rgba(0,150,50,0.8)'}} mode="contained"  onPress={() => {this.setState({preview: !this.state.preview, buttonText: !this.state.buttonText })} }>
          {this.state.buttonText ? 'Preview & Upload Vibe' : 'Back & Edit your Vibe'}
        </Button>

      </Surface>
      </View>


     </View>
    );
  }

   _pickImage = async () => {
    let result = await ImagePicker.launchImageLibraryAsync({
      allowsEditing: true,
      aspect: [16, 9],
    });

    if (!result.cancelled) {
      this.setState({ image: result.uri });
    }
  };
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 0,
    backgroundColor: '#fff',
  },
    container2: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    margin: 5,
    padding: 5,
  },
  bottomContainer: {
    padding: 10,
    flex: 1,
    justifyContent: 'center',

  },
  surface: {
    elevation: 12,
  },
});
