using System.Collections.ObjectModel;
using System.ComponentModel;
using Livet;
using WpdLib.Sample.Models;

namespace WpdLib.Sample.ViewModels
{
	/// <summary>
	/// ポータブル デバイス オブジェクトの ViewModel です。
	/// </summary>
	sealed class PortableDeviceObjectViewModel : ViewModel
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="model">モデル。</param>
		public PortableDeviceObjectViewModel( PortableDeviceObject model )
		{
			this._model = model;
		}

		/// <summary>
		/// フォルダ内のファイル・フォルダを列挙します。
		/// </summary>
		private void EnumChildren()
		{
			this._folders = new ObservableCollection< PortableDeviceObjectViewModel >();
			this.Files    = new ObservableCollection< PortableDeviceObjectViewModel >();

			var worker = new BackgroundWorker() { WorkerReportsProgress = true };

			// 列挙
			worker.DoWork += ( sender, e ) =>
				{
					foreach( var child in this._model.EnumChildren() )
					{
						worker.ReportProgress( 0, child );
					}
				};

			// 追加
			worker.ProgressChanged += ( sender, e ) =>
				{
					var child = e.UserState as PortableDeviceObject;
					if( child == null ) { return; }

					var vm = new PortableDeviceObjectViewModel( child );
					if( child.IsFolder )
					{
						this._folders.Add( vm );
						this.RaisePropertyChanged( "Children" );
					}
					else
					{
						this.Files.Add( vm );
						this.RaisePropertyChanged( "Files" );
					}
				};

			worker.RunWorkerAsync();
		}

		/// <summary>
		/// フォルダ内のファイル情報コレクションを取得します。
		/// </summary>
		public ObservableCollection< PortableDeviceObjectViewModel > Files { get; private set; }

		/// <summary>
		/// サブ フォルダのコレクションを取得します。
		/// </summary>
		public ObservableCollection< PortableDeviceObjectViewModel > Children
		{
			get
			{
				if( this._folders == null )
				{
					this.EnumChildren();
				}

				return this._folders;
			}
		}

		/// <summary>
		/// オブジェクトの識別子を取得します。
		/// </summary>
		public string Id { get { return this._model.Id; } }

		/// <summary>
		/// オブジェクト名を取得します。
		/// </summary>
		public string Name { get { return this._model.Name; } }

		/// <summary>
		/// サイズを取得します。
		/// </summary>
		public long Size { get { return ( long )this._model.Size; } }

		/// <summary>
		/// サブ フォルダのコレクション。
		/// </summary>
		private ObservableCollection< PortableDeviceObjectViewModel > _folders;

		/// <summary>
		/// モデル。
		/// </summary>
		private PortableDeviceObject _model;
	}
}
